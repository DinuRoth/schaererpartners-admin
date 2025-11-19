
using xTend;
using xTend.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;


namespace SchaererPartners {
    public partial class Galerie: DBO {
        public Galerie () : base() { }
        public Galerie (IUserDB db) : base (db) { }

		private System.Int32? _Kategorie;
		private System.String? _Bild;
		private System.String? _Galerie_Bez;
		private System.Int32? _InHauptgalerie;
		private System.DateTime? _Datum;


        [Column]
        [Key]
		public Int32 Galerie_ID { get; set; }
        public override Int32 Id {
            get { return Galerie_ID; }
        }

		[Column]
		public System.Int32? Kategorie {
            get { return _Kategorie; }
            set {
                if (value != _Kategorie) {
                    var oldVal = _Kategorie;
                    _Kategorie = value;
                    OnFieldChanged(nameof(Kategorie), oldVal, value);

                }
            }
        }
		[Column]
		[GUIType(GUIType.Enum.Image)]
		[StringLength(255)]
		public System.String? Bild {
            get { return _Bild; }
            set {
                if (value != _Bild) {
                    var oldVal = _Bild;
                    _Bild = value;
                    OnFieldChanged(nameof(Bild), oldVal, value);

                }
            }
        }
		[Column]
		[StringLength(255)]
		public System.String? Galerie_Bez {
            get { return _Galerie_Bez; }
            set {
                if (value != _Galerie_Bez) {
                    var oldVal = _Galerie_Bez;
                    _Galerie_Bez = value;
                    OnFieldChanged(nameof(Galerie_Bez), oldVal, value);

                }
            }
        }
		[Column]
		public System.Int32? InHauptgalerie {
            get { return _InHauptgalerie; }
            set {
                if (value != _InHauptgalerie) {
                    var oldVal = _InHauptgalerie;
                    _InHauptgalerie = value;
                    OnFieldChanged(nameof(InHauptgalerie), oldVal, value);

                }
            }
        }
		[Column]
		public System.DateTime? Datum {
            get { return _Datum; }
            set {
                if (value != _Datum) {
                    var oldVal = _Datum;
                    _Datum = value;
                    OnFieldChanged(nameof(Datum), oldVal, value);

                }
            }
        }




        public override void SetData(SqlDataReader reader, string prefix="") {
    
			Galerie_ID = (int)reader[prefix + nameof (Galerie_ID)];
			_Kategorie = reader.ToNullableInt (prefix + nameof(Kategorie));
			_Bild = reader.ToNullableString (prefix + nameof(Bild));
			_Galerie_Bez = reader.ToNullableString (prefix + nameof(Galerie_Bez));
			_InHauptgalerie = reader.ToNullableInt (prefix + nameof(InHauptgalerie));
			_Datum = reader.ToNullableDateTime (prefix + nameof(Datum));

        }

        public override void SetDataWithRelated(SqlDataReader reader, IEnumerable<PropertyInfo> foreignProperties) {
            SetData (reader, "main_");

        }

    }
}
