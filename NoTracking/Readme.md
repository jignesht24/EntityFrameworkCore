### Introduction
DbContext in Entity Framework is responsible to track the changes made on the entity or object, so the correct update is done to the database when the SaveChange() method of context is called. When we retrieve entities using an object query, the Entity Framework puts these entities in a cache and tracks whatever changes are made on these entities until the savechanges() method is called. Entity Framework track the queries result that return entity types.

Sometimes we do not want to track some entities because the data is only used for viewing purposes and other operations such as insert, update and delete are not done. For example, the view data in a read-only grid.

In scenario describe above, No-Tracking queries are useful. They are very quick to execute because there is change tracking setup. There is multiple way to achieve no-tracking queries.

No-Tracking query Using AsNoTracking() extension method
The AsNoTracking() extension method returns a new query and returned entities does not track by the context. It means that EF does not perform any additional task to store the retrieve entities for tracking. 

Example
```
using (EntityModelContext context = new EntityModelContext())
{
	var employee = context.Employees.AsNoTracking().ToList();  

    var employee2 = context.Employees  
                    .Where(p => p.Id >= 3)  
                    .AsNoTracking().ToList();  
}
```
 ### Change tracking behaviour at the context instance level
 We can also change the default behaviour of tracking at context instance level. The ChangeTracker class (defined as property of context class) has property called QueryTrackingBehavior, using this property we can change behaviour of tracking. 

Example
```
using (EntityModelContext context = new EntityModelContext())
{
	context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
	...
	...
}
```
### No tracking is performed When result set does not contain any entity types
If our query result does not contain any entity type, it does not track by the change tracker and no tracking is performed. In following query, which returns anonymous type with some of the value of entity, so tracking does not perform.
```
var data2 = context.Employees.Select(p => new
                {
                    name = p.Name,
                    id = p.Id

                }).ToList();
```
Some time, result set does not an entity, even if this entity tracks by default due to result contains entity type. In following query, result is an anonymous type but instance of employee in result set, so this will be tracked.
```
 var data2 = context.Employees.Select(emp => new
                {
                    Id = emp.Id,
					Employee = emp

                }).ToList();
```

No Tracking can save both execution times and memory usage. Applying this option really becomes important when we retrieve a large amount of data from the database for read only purpose.