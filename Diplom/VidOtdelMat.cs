//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Drawing;
    using System.IO;

    public partial class VidOtdelMat
    {
        public int Id_VidOtdelMat { get; set; }
        public byte[] Foto { get; set; }
        public string VidOtdelMat1 { get; set; }
        public string Cvet { get; set; }
        public string FotoGraphy  {get; set; }
        [NotMapped]
    public Image Picture
        {
            get
            {
                if(!string.IsNullOrEmpty(FotoGraphy))
                {
                    if (File.Exists(FotoGraphy))
                        return Image.FromFile(FotoGraphy);
                }
                return null;
            }
        }
    }
}
