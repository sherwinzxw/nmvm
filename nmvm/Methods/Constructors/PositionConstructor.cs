using System;

namespace nmvm.Models.nmvm
{
    public partial class Position
    {
        /// <summary>
         /// Construct a new position with new default values;
         /// </summary>
         /// <param name="position">The position data from the POST method</param>
         /// <returns></returns>
        public Position New(Position position)
        {
            DateTime currentTimestamp = DateTime.Now;
            position.CreatedDateTime = currentTimestamp;
            position.ModifiedDateTime = currentTimestamp;
            return position;
        }
    }
}