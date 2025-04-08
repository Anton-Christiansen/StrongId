# Strong Id
## A source generated strongly typed identifier

How to use:

Mark your classes with the **[StrongId]** attribute, and make the class partial.
The source generator will then generate a record (the strongly typed id), and a property on the marked class

## Parameters

1) "ParameterType" a Type property of the inner value type (defaults to System.Guid)
2) "ParameterName" a string property of the property name in the marked class
