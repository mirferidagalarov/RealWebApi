using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Repositories;
using RealEstate.Domain.Entities;
using RealEstate.Infrastructure.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Persistence.Repositories
{
    public class AnnouncementSpecificationRepository 
        : GeneralRepository<AnnouncementSpecification>, IAnnouncementSpecificationRepository

    {

        public AnnouncementSpecificationRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
