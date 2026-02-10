namespace NewsApi.Domain.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    private Category(int id,string name)
    {
        Name = name;
        Id = id;
    }
    
    public static Category Create(int id,string name = null)
    {
        //TODO: Validate parameters
        
        return new Category(id,name);
    }
    
}

