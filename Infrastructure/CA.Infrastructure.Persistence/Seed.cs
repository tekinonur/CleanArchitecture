using CA.Core.Domain.Entities;
using CA.Core.Domain.IRepositories.Base;

namespace CA.Infrastructure.Persistence
{
    public class Seed
    {
        /// <summary>
        /// Data Insert
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <returns></returns>
        public static async Task SeedData(IUnitOfWork unitOfWork)
        {
            if (await unitOfWork.Users.Any() == false)
            {
                var id = Guid.NewGuid();

                var users = new List<User>(){
                    new User(){
                        ID = id,
                        FirstName = "Admin",
                        LastName = "Administrator",
                        Email = "admin@gmail.com",
                        CreatedBy = id,
                        CreatedOn = DateTime.Now,
                        UpdatedBy = id
                    },
                    new User(){
                        ID = Guid.NewGuid(),
                        FirstName = "User",
                        LastName = "BasicUser",
                        Email = "user@gmail.com",
                        CreatedBy = id,
                        CreatedOn = DateTime.Now,
                        UpdatedBy = id
                    }
                };

                foreach (var user in users)
                {
                    await unitOfWork.Users.Add(user);
                }

                var items = new List<Item>(){
                    new Item(){
                        ID = Guid.NewGuid(),
                        Name = "Item1"
                    },
                    new Item(){
                      ID = Guid.NewGuid(),
                      Name = "Item2"
                    }
                };

                foreach (var item in items)
                {
                    await unitOfWork.Items.Add(item);
                }

                await unitOfWork.CompleteAsync();
            }
        }
    }
}