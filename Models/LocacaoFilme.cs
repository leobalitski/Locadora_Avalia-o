using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    /// <summary>
    /// 'N to N' relation class
    /// </summary>
    public class LocacaoFilmeModels
    {
        /// <value> Get and Set the value of ID </value>
        [Key] // Data Annotations - Main key
        public int Id { get; set; }

        /// <value> Get and Set the value of IdLocacao </value>
        [ForeignKey("locacoes")] // Data Annotations - Foreign Key
        public int IdLocacao { get; set; }

        /// <value> Get and Set the value of Locacao </value>
        public virtual LocacaoModels Locacao { get; set; }

        /// <value> Get and Set the value of IdFilme </value>
        [ForeignKey("filmes")] // Data Annotations - Foreign Key
        public int IdFilme { get; set; }

        /// <value> Get and Set the value of Filme </value>
        public virtual FilmeModels Filme { get; set; }

    }
}