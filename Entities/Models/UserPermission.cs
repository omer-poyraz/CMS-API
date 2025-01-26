using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Entities.Models
{
    public class UserPermission
    {
        public int ID { get; set; }
        public string? userId { get; set; }
        public User? user { get; set; }
        public string? service_name { get; set; }
        public bool can_super_admin { get; set; }
        public bool can_read { get; set; }
        public bool can_write { get; set; }
        public bool can_delete { get; set; }
        public bool can_btk { get; set; }
        public bool can_hosting { get; set; }
        public bool can_consumer { get; set; }
        public bool can_ethernet { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
