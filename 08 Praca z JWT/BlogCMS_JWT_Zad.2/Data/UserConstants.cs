using BlogCMS.Models;

namespace BlogCMS.Data
{
    public class UserConstants
    {
        public static List<LoginModel> Users = new()
        {
                new LoginModel(){ Username="Piotr",Password="TajneHaslo_1234",Role="Admin"}
        };
    }
}