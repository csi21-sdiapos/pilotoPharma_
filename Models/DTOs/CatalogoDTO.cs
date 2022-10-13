namespace PilotoPharma.Models.DTOs
{
    public class CatalogoDTO
    {
        // ATRIBUTOS
        string md_uuid;                     // Código de metadato que indica el grupo de inserción al que pertenece el registro.
        DateTime md_fch;                    // Fecha en la que se define el grupo de inserción.
        int id_producto;                    // Código numérico autoincremental que identifica unívocamente al producto dentro del sistema.
        string cod_producto;                // Código alfanumérico que identifica unívocamente al producto dentro del catálogo.
        string nombre_producto;             // Nombre del producto
        string tipo_producto_origen;        // Laboratorio en el que se desarrolla el producto: “Propio” o “Externo”.
        string tipo_producto_clase;         // Tipo del producto: “Analgésico”, “Antiséptico”, etc.
        string des_producto;                // Descripción básica del producto.
        DateTimeOffset fch_alta_producto;   // Fecha de alta del producto en el catálogo.
        DateTimeOffset fch_baja_producto;   // Fecha de baja del producto en el catálogo.


        // CONSTRUCTORES

        // constructor lleno
        public CatalogoDTO(string md_uuid, DateTime md_fch, int id_producto, string cod_producto, string nombre_producto, string tipo_producto_origen, string tipo_producto_clase, string des_producto, DateTimeOffset fch_alta_producto, DateTimeOffset fch_baja_producto)
        {
            this.md_uuid = md_uuid;
            this.md_fch = md_fch;
            this.id_producto = id_producto;
            this.cod_producto = cod_producto;
            this.nombre_producto = nombre_producto;
            this.tipo_producto_origen = tipo_producto_origen;
            this.tipo_producto_clase = tipo_producto_clase;
            this.des_producto = des_producto;
            this.fch_alta_producto = fch_alta_producto;
            this.fch_baja_producto = fch_baja_producto;
        }

        // constructor vacío
        public CatalogoDTO()
        {
        }


        // GETTERS Y SETTERS
        public string Md_uuid { get => md_uuid; set => md_uuid = value; }
        public DateTime Md_fch { get => md_fch; set => md_fch = value; }
        public int Id_producto { get => id_producto; set => id_producto = value; }
        public string Cod_producto { get => cod_producto; set => cod_producto = value; }
        public string Nombre_producto { get => nombre_producto; set => nombre_producto = value; }
        public string Tipo_producto_origen { get => tipo_producto_origen; set => tipo_producto_origen = value; }
        public string Tipo_producto_clase { get => tipo_producto_clase; set => tipo_producto_clase = value; }
        public string Des_producto { get => des_producto; set => des_producto = value; }
        public DateTimeOffset Fch_alta_producto { get => fch_alta_producto; set => fch_alta_producto = value; }
        public DateTimeOffset Fch_baja_producto { get => fch_baja_producto; set => fch_baja_producto = value; }


        // ToString
        public override string ToString()
        {
            return String.Format
                (
                    "\n\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}",

                    md_uuid,
                    md_fch,
                    id_producto,
                    cod_producto,
                    nombre_producto,
                    tipo_producto_origen,
                    tipo_producto_clase,
                    des_producto,
                    fch_alta_producto,
                    fch_baja_producto
                );
        }
    }
}
