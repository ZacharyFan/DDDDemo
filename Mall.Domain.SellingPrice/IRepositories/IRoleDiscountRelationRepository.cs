using Mall.Domain.SellingPrice.MemberPrice.ValueObject;

namespace Mall.Domain.SellingPrice.IRepositories
{
    public interface IRoleDiscountRelationRepository// : IRepository<RoleDiscountRelation>
    {
        RoleDiscountRelation Get(string roleId);
    }
}
