using Swashbuckle.AspNetCore.Annotations;

namespace LearningCenter.API.Learning.Resources;

[SwaggerSchema(Required = new []{"Id", "Name"})]
public class CategoryResource
{
    [SwaggerSchema("Category Identifier")]
    public int Id { get; set; }
    [SwaggerSchema("Category Name")]
    public string Name { get; set; }
}