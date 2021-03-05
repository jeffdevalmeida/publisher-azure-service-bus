using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp
{
    public class UserFollowingInputModel
    {
        public UserFollowingInputModel(string idUserFollower, string idUserFollowee, string email)
        {
            IdUserFollower = idUserFollower;
            IdUserFollowee = idUserFollowee;
            FollowedAt = DateTime.Now;
            Email = email;
        }

        public string IdUserFollower { get; private set; }
        public string IdUserFollowee { get; private set; }
        public DateTime FollowedAt { get; private set; }
        public string Email { get; private set; }
    }
}
