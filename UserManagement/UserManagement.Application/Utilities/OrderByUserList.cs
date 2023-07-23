using DTO = UserManagement.Domain.DTO;
using Entity = UserManagement.Domain.Entities;

namespace UserManagement.Application.Utilities
{
    internal class OrderByUserList
    {
        public static Func<IQueryable<Entity.User>, IOrderedQueryable<Entity.User>> GetOrderBy(DTO.Paginate paginate)
        {
            Func<IQueryable<Entity.User>, IOrderedQueryable<Entity.User>>? response = null;

            if (paginate.Ascendent)
            {
                switch (paginate.OrderBy.ToLower())
                {
                    case "name":
                        {
                            response = x => x.OrderBy(x => x.Name);
                            break;
                        }
                    case "lastname":
                        {
                            response = x => x.OrderBy(x => x.Lastname);
                            break;
                        }
                    case "email":
                        {
                            response = x => x.OrderBy(x => x.Email);
                            break;
                        }
                    default:
                        {
                            response = x => x.OrderBy(x => x.Name);
                            break;
                        }
                }
            }
            else
            {
                switch (paginate.OrderBy.ToLower())
                {
                    case "name":
                        {
                            response = x => x.OrderByDescending(x => x.Name);
                            break;
                        }
                    case "lastname":
                        {
                            response = x => x.OrderByDescending(x => x.Lastname);
                            break;
                        }
                    case "email":
                        {
                            response = x => x.OrderByDescending(x => x.Email);
                            break;
                        }
                    default:
                        {
                            response = x => x.OrderByDescending(x => x.Name);
                            break;
                        }
                }
            }

            return response;
        }
    }
}
