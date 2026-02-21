# Strong Id
## A source generated strongly typed identifier

How to use:

Mark your classes with the **[StrongId]** attribute, and make the class partial.
The source generator will then generate a readonly record struct (the strongly typed id), and a property on the marked class

## Parameters

1) "ParameterType" a Type property of the inner value type (defaults to System.Guid)
2) "ParameterName" a string property of the property name in the marked class (defaults to "Id")

## Example

```
[StrongId]
public partial class Order
{
    
}
```

Generates the following classes

Partial:
```
public partial class Order
{
	public OrderId Id { get; private set; }
}
```

Record:

```
public readonly record struct OrderId(System.Guid Value)
{
    public static OrderId Create(System.Guid id) => new OrderId(id);
}
```