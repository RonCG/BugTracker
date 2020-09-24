using System;
using System.Collections.Generic;
using System.Text;

namespace BugTracker.Data.Models
{
    public class RoleModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public static explicit operator RoleModel(Role v)
        {
            return new RoleModel
            {
                RoleId = v.RoleId,
                Name = v.Name,
                Description = v.Description,
                Active = v.Active
            };
        }
    }
}
