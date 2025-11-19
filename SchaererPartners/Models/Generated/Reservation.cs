
using xTend;
using xTend.Service;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Reflection;


namespace SchaererPartners {
    public partial class Reservation: DBO {
        public Reservation () : base() { }
        public Reservation (IUserDB db) : base (db) { }

		private System.Int32 _Event_FK;
		private System.String _Name;
		private System.String _Vorname;
		private System.String? _Adresse;
		private System.String? _PLZ;
		private System.String? _Ort;
		private System.String? _Telefon;
		private System.String? _Email;
		private System.Int32 _Seats;
		private System.Boolean _Mitglied;
		private System.Boolean _BestaetigungGeschickt;


        [Column]
        [Key]
		public Int32 Reservation_ID { get; set; }
        public override Int32 Id {
            get { return Reservation_ID; }
        }

		[Column]
		[ForeignKey ("Event")]
		public System.Int32 Event_FK {
            get { return _Event_FK; }
            set {
                if (value != _Event_FK) {
                    var oldVal = _Event_FK;
                    _Event_FK = value;
                    OnFieldChanged(nameof(Event_FK), oldVal, value);

                }
            }
        }
		[Column]
		[StringLength(255)]
		public System.String Name {
            get { return _Name; }
            set {
                if (value != _Name) {
                    var oldVal = _Name;
                    _Name = value;
                    OnFieldChanged(nameof(Name), oldVal, value);

                }
            }
        }
		[Column]
		[StringLength(255)]
		public System.String Vorname {
            get { return _Vorname; }
            set {
                if (value != _Vorname) {
                    var oldVal = _Vorname;
                    _Vorname = value;
                    OnFieldChanged(nameof(Vorname), oldVal, value);

                }
            }
        }
		[Column]
		[StringLength(255)]
		public System.String? Adresse {
            get { return _Adresse; }
            set {
                if (value != _Adresse) {
                    var oldVal = _Adresse;
                    _Adresse = value;
                    OnFieldChanged(nameof(Adresse), oldVal, value);

                }
            }
        }
		[Column]
		[StringLength(255)]
		public System.String? PLZ {
            get { return _PLZ; }
            set {
                if (value != _PLZ) {
                    var oldVal = _PLZ;
                    _PLZ = value;
                    OnFieldChanged(nameof(PLZ), oldVal, value);

                }
            }
        }
		[Column]
		[StringLength(255)]
		public System.String? Ort {
            get { return _Ort; }
            set {
                if (value != _Ort) {
                    var oldVal = _Ort;
                    _Ort = value;
                    OnFieldChanged(nameof(Ort), oldVal, value);

                }
            }
        }
		[Column]
		[StringLength(255)]
		public System.String? Telefon {
            get { return _Telefon; }
            set {
                if (value != _Telefon) {
                    var oldVal = _Telefon;
                    _Telefon = value;
                    OnFieldChanged(nameof(Telefon), oldVal, value);

                }
            }
        }
		[Column]
		[StringLength(255)]
		public System.String? Email {
            get { return _Email; }
            set {
                if (value != _Email) {
                    var oldVal = _Email;
                    _Email = value;
                    OnFieldChanged(nameof(Email), oldVal, value);

                }
            }
        }
		[Column]
        [Aggregation (AggregationAttribute.Enum.Sum)]
        public System.Int32 Seats {
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
		public System.Boolean Mitglied {
            get { return _Mitglied; }
            set {
                if (value != _Mitglied) {
                    var oldVal = _Mitglied;
                    _Mitglied = value;
                    OnFieldChanged(nameof(Mitglied), oldVal, value);

                }
            }
        }
		[Column]
		public System.Boolean BestaetigungGeschickt {
            get { return _BestaetigungGeschickt; }
            set {
                if (value != _BestaetigungGeschickt) {
                    var oldVal = _BestaetigungGeschickt;
                    _BestaetigungGeschickt = value;
                    OnFieldChanged(nameof(BestaetigungGeschickt), oldVal, value);

                }
            }
        }

		public Event? _Event;
       [GUIType(GUIType.Enum.Hidden)]
        public Event? Event {
            get {
                if (_Event == null) {
                    _Event = Database.Read<Event> (Event_FK);
                }
                return _Event;
            }
            set {
                _Event = value;
    Event_FK = value.Id;
            }
        }



        public override void SetData(SqlDataReader reader, string prefix="") {
    
			Reservation_ID = (int)reader[prefix + nameof (Reservation_ID)];
			_Event_FK = (System.Int32) reader[prefix + nameof(Event_FK)];
			_Name = (System.String) reader[prefix + nameof(Name)];
			_Vorname = (System.String) reader[prefix + nameof(Vorname)];
			_Adresse = reader.ToNullableString (prefix + nameof(Adresse));
			_PLZ = reader.ToNullableString (prefix + nameof(PLZ));
			_Ort = reader.ToNullableString (prefix + nameof(Ort));
			_Telefon = reader.ToNullableString (prefix + nameof(Telefon));
			_Email = reader.ToNullableString (prefix + nameof(Email));
			_Seats = (System.Int32) reader[prefix + nameof(Seats)];
			_Mitglied = (System.Boolean) reader[prefix + nameof(Mitglied)];
			_BestaetigungGeschickt = (System.Boolean) reader[prefix + nameof(BestaetigungGeschickt)];

        }

        public override void SetDataWithRelated(SqlDataReader reader, IEnumerable<PropertyInfo> foreignProperties) {
            SetData (reader, "main_");

            if (Event_FK != null) {
    Event = new Event (Database);
    Event.SetData (reader, nameof (Event) + "_");
            }

        }

    }
}
