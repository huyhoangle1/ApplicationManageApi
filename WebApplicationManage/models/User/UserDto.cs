﻿using WebApplicationManage.Data;

namespace WebApplicationManage.models.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public Role? Role { get; set; }
    }
}
