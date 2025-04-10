StrongId - A strongly typed identifier

Following the spirit of Domain-Driven-Design and value objects, this makes it easy to source generate strongly typed identifiers for your entities.
Mark your class(es) with an [StrongId] Attribute

Available as a nuget package:
                
    Anton_Christiansen.StrongId

This will then generate two files:

1) A sealed record with the class same appended with Id, with a single property (defaults to System.Guid, override it with ParameterType) called Value.

2) A partial class adding the strongly typed identifier as property (defaults to: "Id", override it with ParameterName).

Example:

    [StrongId]
    public partial class SampleEntity
    {
      ...
    }

will generate the following files:

1

    public sealed record SampleEntityId
    {
      private SampleEntityId(System.Guid id)
      {
        Value = id;
      }

      public System.Guid Value { get; init; }

      public static SampleEntityId Create(System.Guid id) => new SampleEntityId(id);
    }
    
2

    public partial class SampleEntity
    {
      public SampleEntityId Id { get; private set; }
    }







Example 2:

    [StrongId(ParameterType = typeof(int), ParameterName = "PrimaryKey")]
    public partial class SampleEntity
    {
      ...
    }

will generate the following files:

1

    public sealed record SampleEntityId
    {
      private SampleEntityId(int id)
      {
        Value = id;
      }

      public int Value { get; init; }

      public static SampleEntityId Create(int id) => new SampleEntityId(id);
    }
    
2

    public partial class SampleEntity
    {
      public SampleEntityId PrimaryKey { get; private set; }
    }

