using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Model
{
    [Serializable]
    public class RoomListModel
    {
        public string RoomNo { get; set; }
        public int CardQTY { get; set; }
        public string State { get; set; }

    }
}
