﻿using GraduationProject.Data;
using GraduationProject.Infrastructures.Repositories;
using GraduationProject.Models.Entities;

namespace GraduationProject.Applications.VendorContacts
{
    public class VendorContactService : Repository<FactoriesContacts>
    {
        public VendorContactService(
            ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor,
            IAuditColumnTransformer auditColumnTransformer) :
                base(
                    context,
                    httpContextAccessor,
                    auditColumnTransformer)
        {
        }


    }
}
