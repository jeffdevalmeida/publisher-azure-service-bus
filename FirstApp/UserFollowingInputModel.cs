using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp
{
    public class UserFollowingInputModel
    {
        public UserFollowingInputModel(int idUserFollower, int idUserFollowee, string email)
        {
            IdUserFollower = idUserFollower;
            IdUserFollowee = idUserFollowee;
            FollowedAt = DateTime.Now;
            Email = email;
        }

        public int IdUserFollower { get; private set; }
        public int IdUserFollowee { get; private set; }
        public DateTime FollowedAt { get; private set; }
        public string Email { get; private set; }
    }
}
