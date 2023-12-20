namespace WebAPI.Service;

public class UserService
{
    private readonly List<User> users;

    public UserService()
    {

        users = new()
        {
            new(){Id=0,Name="Tamer",Password="Tt1234!.",Email="greenpeace@hotmail.com",Phone="5055929385",Role="Admin"},
            new(){Id=1,Name="Ahmet",Password="Aa1234!.",Email="ahmet@hotmail.com",Phone="5342563638",Role="Editor"},
            new(){Id=2,Name="Ebru",Password="Ee1234!.",Email="ebru@hotmail.com",Phone="5425263857",Role="Author"},
            new(){Id=3,Name="Esin",Password="Es1234!.",Email="esin@hotmail.com",Phone="5425265874",Role="Author"},
            new(){Id=4,Name="Neslihan",Password="Nn1234!.",Email="neslihan@hotmail.com",Phone="5536341528",Role="Author"}
        };
    }

    public User ValidateUser(string username, string password)
    {
        return users.FirstOrDefault(u => u.Name == username && u.Password == password);
    }
}

