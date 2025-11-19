
using xTend;
using xTend.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;


namespace SchaererPartners {
    public partial class Dokument: DBO {
        public Dokument () : base() { }
        public Dokument (IUserDB db) : base (db) { }

		private System.String? _Dokument_Bez;
		private System.String? _PDF;


        [Column]
        [Key]
		public Int32 Dokument_ID { get; set; }
        public override Int32 Id {
            get { return Dokument_ID; }
        }

		[Column]
		[StringLength(255)]
		public System.String? Dokument_Bez {
            get { return _Dokument_Bez; }
            set {
                if (value != _Dokument_Bez) {
                    var oldVal = _Dokument_Bez;
                    _Dokument_Bez = value;
                    OnFieldChanged(nameof(Dokument_Bez), oldVal, value);

                }
            }
        }
		[Column]
		[StringLength(255)]
		public System.String? PDF {
            get { return _PDF; }
            set {
                if (value != _PDF) {
                    var oldVal = _PDF;
                    _PDF = value;
                    OnFieldChanged(nameof(PDF), oldVal, value);

                }
            }
        }




        public override void SetData(SqlDataReader reader, string prefix="") {
    
			Dokument_ID = (int)reader[prefix + nameof (Dokument_ID)];
			_Dokument_Bez = reader.ToNullableString (prefix + nameof(Dokument_Bez));
			_PDF = reader.ToNullableString (prefix + nameof(PDF));

        }

        public override void SetDataWithRelated(SqlDataReader reader, IEnumerable<PropertyInfo> foreignProperties) {
            SetData (reader, "main_");

        }

    }
}
