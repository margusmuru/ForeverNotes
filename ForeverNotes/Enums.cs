using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeverNotes
{
    public class Enums
    {


        public enum Status { Create, Update, UpdateGroup, UpdateGroupItems, UpdateGroupAndItems, Remove, Synced, LeaveIt };


        /**
         * Method to manage status change depending on events between syncing with database
         */
        public static Status GetStatus(Status curStatus, Status newStatus)
        {
            if (curStatus == Status.Create && newStatus != Status.Remove)
                return Status.Create;

            if (curStatus == Status.Create && newStatus == Status.UpdateGroup)
                return Status.Create;

            if (curStatus == Status.Create && newStatus == Status.Remove)
                return Status.LeaveIt;

            return newStatus;
        }

        public static Status GetGroupStatus(Status curStatus, Status newStatus)
        {
            if (curStatus == Status.Create && newStatus == Status.UpdateGroup)
                return Status.Create;

            if (curStatus == Status.Create && newStatus == Status.Remove)
                return Status.LeaveIt;

            if (curStatus == Status.Create && newStatus == Status.UpdateGroupItems)
                return Status.Create;

            if (curStatus == Status.UpdateGroup && newStatus == Status.UpdateGroupItems)
                return Status.UpdateGroupAndItems;


            return newStatus;
        }
    }
}
