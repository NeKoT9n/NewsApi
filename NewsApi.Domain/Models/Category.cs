namespace NewsApi.Domain.Models;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    private Category(long id,string name)
    {
        Name = name;
        Id = id;
    }
    
    public static Category Create(long id,string name)
    {
        //TODO: Validate parameters
        
        return new Category(id,name);
    }
}

