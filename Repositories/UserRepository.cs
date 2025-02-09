using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories{

public class UserRepository : Repository<User>{
    private readonly SqlConnection _connection;

    public UserRepository(SqlConnection connection) : base(connection){
        _connection = connection;      
    }

    public List<User> GetRoles(){
        var sql = @"
            SELECT
                *
            FROM
                [User]
                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
        ";

        var users = new List<User>();
        var items = _connection.Query<User, Role, User>(sql, (user,role) => {
            var usr = users.FirstOrDefault(x => x.Id == user.Id);
            if (usr == null){
                usr = user;
                //error: object reference not set to an instance of an object 
                if (role != null){
                    usr.Roles.Add(role);
                }
                users.Add(usr);
            }
            else{
                usr.Roles.Add(role);
            }

            return user;
        }, splitOn: "Id");
    return users;   
    }
}
}