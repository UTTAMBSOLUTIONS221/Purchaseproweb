﻿namespace Purchaseproweb.Models
{
    public class SystemPermissions
    {
        public long PermissionId { get; set; }
        public string? Permissionname { get; set; }
        public bool Isactive { get; set; }
        public bool Isdeleted { get; set; }
        public int Module { get; set; }
        public bool Isadmin { get; set; }
        public int RoleId { get; set; }
    }
}
