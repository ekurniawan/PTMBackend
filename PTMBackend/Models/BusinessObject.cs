using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PTMBackend.Models
{
    public class COIDetail
    {
        public string COINumber { get; set; }
        public string PolNumber { get; set; }
        public int IdTipeStatus { get; set; }
        public string DestinationPort { get; set; }
        public string VesselName { get; set; }

        public TipeStatus TipeStatus { get; set; }
    }

    public class Pengguna
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int IdTipeUser { get; set; }

        public TipeUser TipeUser { get; set; }
    }

    public class TipeStatus
    {
        public TipeStatus()
        {
            this.CoiDetails = new List<COIDetail>();
        }

        public int IdTipeStatus { get; set; }
        public string NamaTipe { get; set; }

        public List<COIDetail> CoiDetails { get; set; }
    }

    public class TipeUser
    {
        public TipeUser()
        {
            this.Penggunas = new List<Pengguna>();
        }

        public int IdTipeUser { get; set; }
        public string NamaTipe { get; set; }
        public bool IsConfirm { get; set; }
        public bool IsRequest { get; set; }
        public bool IsReview { get; set; }
        public bool IsApprove { get; set; }
        public bool IsAccept { get; set; }

        public List<Pengguna> Penggunas { get; set; }
    }

}