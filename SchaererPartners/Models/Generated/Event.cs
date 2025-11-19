
using xTend;
using xTend.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;


namespace SchaererPartners {
    public partial class Event: DBO {
        public Event () : base() { }
        public Event (IUserDB db) : base (db) { }

		private System.DateTime? _Datum;
		private System.String? _Event_Bez;
		private System.String? _Artist;
		private System.String? _Foto;
		private System.String? _Text;
		private System.String? _LineUp;
		private System.String? _Website;
		private System.Int32? _Seats;
		private System.String? _ReservationsUrl;


        [Column]
        [Key]
		public Int32 Event_ID { get; set; }
        public override Int32 Id {
            get { return Event_ID; }
        }

		[Column]
		[GUIType(GUIType.Enum.DateTime)]
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
		[Column]
		[StringLength(255)]
		public System.String? Event_Bez {
            get { return _Event_Bez; }
            set {
                if (value != _Event_Bez) {
                    var oldVal = _Event_Bez;
                    _Event_Bez = value;
                    OnFieldChanged(nameof(Event_Bez), oldVal, value);

                }
            }
        }
		[Column]
		[GUIType(GUIType.Enum.Hidden)]
		[StringLength(255)]
		public System.String? Artist {
            get { return _Artist; }
            set {
                if (value != _Artist) {
                    var oldVal = _Artist;
                    _Artist = value;
                    OnFieldChanged(nameof(Artist), oldVal, value);

                }
            }
        }
		[Column]
		[GUIType(GUIType.Enum.Image)]
		[StringLength(255)]
		public System.String? Foto {
            get { return _Foto; }
            set {
                if (value != _Foto) {
                    var oldVal = _Foto;
                    _Foto = value;
                    OnFieldChanged(nameof(Foto), oldVal, value);

                }
            }
        }
		[Column]
		[GUIType(GUIType.Enum.HTML)]
		[StringLength(2147483647)]
		public System.String? Text {
            get { return _Text; }
            set {
                if (value != _Text) {
                    var oldVal = _Text;
                    _Text = value;
                    OnFieldChanged(nameof(Text), oldVal, value);

                }
            }
        }
		[Column]
		[GUIType(GUIType.Enum.HTML)]
		[StringLength(2147483647)]
		public System.String? LineUp {
            get { return _LineUp; }
            set {
                if (value != _LineUp) {
                    var oldVal = _LineUp;
                    _LineUp = value;
                    OnFieldChanged(nameof(LineUp), oldVal, value);

                }
            }
        }
		[Column]
		[StringLength(255)]
		public System.String? Website {
            get { return _Website; }
            set {
                if (value != _Website) {
                    var oldVal = _Website;
                    _Website = value;
                    OnFieldChanged(nameof(Website), oldVal, value);

                }
            }
        }
		[Column]
		public System.Int32? Seats {
            get { return _Seats; }
            set {
                if (value != _Seats) {
                    var oldVal = _Seats;
                    _Seats = value;
                    OnFieldChanged(nameof(Seats), oldVal, value);

                }
            }
        }
		[Column]
		[GUIType(GUIType.Enum.Hidden)]
		[StringLength(250)]
		public System.String? ReservationsUrl {
            get { return _ReservationsUrl; }
            set {
                if (value != _ReservationsUrl) {
                    var oldVal = _ReservationsUrl;
                    _ReservationsUrl = value;
                    OnFieldChanged(nameof(ReservationsUrl), oldVal, value);

                }
            }
        }



        private List<Reservation>? _Reservation_Liste;
        [InverseProperty("Event_FK")]
        public List<Reservation> Reservation_Liste {
            get {
                if (_Reservation_Liste == null) {
                    _Reservation_Liste = Database.ReadMultiple<Reservation> ($"{nameof (Reservation.Event_FK)} = {Event_ID}");
                }
                return _Reservation_Liste;
            }
            set {
                _Reservation_Liste = value;
            }
        }


        public override void SetData(SqlDataReader reader, string prefix="") {
    
			Event_ID = (int)reader[prefix + nameof (Event_ID)];
			_Datum = reader.ToNullableDateTime (prefix + nameof(Datum));
			_Event_Bez = reader.ToNullableString (prefix + nameof(Event_Bez));
			_Artist = reader.ToNullableString (prefix + nameof(Artist));
			_Foto = reader.ToNullableString (prefix + nameof(Foto));
			_Text = reader.ToNullableString (prefix + nameof(Text));
			_LineUp = reader.ToNullableString (prefix + nameof(LineUp));
			_Website = reader.ToNullableString (prefix + nameof(Website));
			_Seats = reader.ToNullableInt (prefix + nameof(Seats));
			_ReservationsUrl = reader.ToNullableString (prefix + nameof(ReservationsUrl));

        }

        public override void SetDataWithRelated(SqlDataReader reader, IEnumerable<PropertyInfo> foreignProperties) {
            SetData (reader, "main_");

        }

    }
}
