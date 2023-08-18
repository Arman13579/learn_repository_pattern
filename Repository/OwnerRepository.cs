using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
           
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return FindAll().OrderBy(ow => ow.Name).ToList();
        }

        public Owner GetOwnerById(string? ownerId)
        {
            return FindByCondition(owner => owner.Id.Equals(ownerId)).FirstOrDefault()!;
        }

        public Owner GetOwnerWithDetails(string? ownerId)
        {


            return FindByCondition(owner => owner.Id.Equals(ownerId))
                    .Include(acc => acc.Accounts)
                    .FirstOrDefault()!;

        }





        public static bool IsNotNull([NotNullWhen(true)] object? obj) => obj != null;

        public void CreateOwner(Owner owner)
        {
            Create(owner);
        }
    }
}
