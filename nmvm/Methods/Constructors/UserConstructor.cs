using System;

namespace nmvm.Models.nmvm
{
    public partial class User
    {
        /// <summary>
        /// Construct a new user with new default values;
        /// </summary>
        /// <param name="user">The user data from the POST method</param>
        /// <returns></returns>
        public User New(User user) {
            DateTime currentTimestamp = DateTime.Now;
            user.CreatedDateTime = currentTimestamp;
            user.ModifiedDateTime = currentTimestamp;
            return user;
        }
    }
}