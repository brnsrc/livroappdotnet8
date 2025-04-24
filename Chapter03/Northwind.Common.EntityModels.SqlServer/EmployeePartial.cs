using System.ComponentModel.DataAnnotations.Schema; // IMaterializationInterceptor, MaterializationInterceptionData
namespace Northwind.EntityModels;
public partial class Employee : IHasLastRefreshed
{
    [NotMapped]
    public DateTimeOffset LastRefreshed { get; set; }
}