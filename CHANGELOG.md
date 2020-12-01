CHANGELOG
============
# December 1st, 2020

## Schema Change

This update includes changes to the application schema. Because of this, if you had used the previous version you may need to update your data to continue proper functionality

- The documents of concern are in the Steps collection
- The specific entity involved is the GraphNode and more specifically the GraphNode.ParentId
  - ParentId was previously a string value, moving forward it is a string[] value
- At the end of this changelog, we have included the script we used to migrate our data in hopes it will help others migrate theirs

## New Features

Below are a list of the features implemented in this release

- Individual events in a scenario may now have graph nodes with multiple parent nodes. This allows for more detailed graph generation showing relations between nodes that lead to a given outcome
- Multiple areas are now filterable based on user input
  - MITRE ATT&CK selection
  - Importing Steplates into Events
  - Editing Steplates
- Graph Nodes have a preview icon displayed once selected while editing a Step
- Steps that have been created under a Scenario can be exported to the Steplates section once saved for later use
- MITRE ATT&CK
  - MITRE has since release of ETM updated the ATT&CK framework
  - This change deprecated the PRE-ATT&CK tactics and techniques and rolled them into ENTERPRISE-ATT&CK
  - As of the time of this update, ETM is in line with current MITRE ATT&CK techniques that have also been added
  - Previous threat matrices generated with ETM will still provide use to client's as MITRE provides redirects to the deprecated techniques

## Data Migration Steps

### First where GraphNode is null, attempt to set it with it's members:
```
> db.Steps.find({"GraphNode":null}).forEach(function(myDoc){ db.Steps.update( { _id: myDoc._id }, { "$set": { "GraphNode.ParentId": "na", "GraphNode.EntityType": "na", "GraphNode.EntityDescription": "na", "GraphNode.Risk": "na", "GraphNode._id": "na" } } ); })
```

### Second, there may be some nulls there still. Check
```
> db.Steps.find({"GraphNode":null}).count()
```

### Third, if there are, unset GraphNode
```
> db.Steps.find({"GraphNode":null}).forEach(function(myDoc){ db.Steps.update( { _id: myDoc._id }, { "$unset" : { "GraphNode": null } } ); })
```

### Fourth, re-set for those two
```
> db.Steps.find({"GraphNode":null}).forEach(function(myDoc) { db.Steps.update( { _id: myDoc._id }, { "$set": { "GraphNode.ParentId": "na", "GraphNode.EntityType": "na", "GraphNode.EntityDescription": "na", "GraphNode.Risk": "na", "GraphNode._id": "na" } } ); })
```

### Fifth, check and replace any ParentIds that are null
```
> db.Steps.find({"GraphNode.ParentId":null}).forEach(function(myDoc){ db.Steps.update( { _id: myDoc._id }, { "$set": { "GraphNode.ParentId": "na" } } ); })
```

### Sixth, turn all of your string type ParentIds to array type
```
> db.Steps.find().forEach(function(myDoc){ db.Steps.update( { _id: myDoc._id }, { "$set": { "GraphNode.ParentId": [myDoc.GraphNode.ParentId] } } ); })
```

### Finally, confirm the array count is the total count of entries
```
> db.Steps.find({"GraphNode.ParentId": {"$type": "array"}}).count()
> db.Steps.find().count()
```