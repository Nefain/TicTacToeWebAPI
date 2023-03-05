using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tic_Tac_ToeWebAPI.Models
{
    public class TicTacToe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Guid GameId { get; set; }
    }
}
