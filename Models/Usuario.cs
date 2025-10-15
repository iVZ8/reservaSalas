﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reservaSalas.Models
{
    [Table("Usuarios")]
    [Index(nameof(Email), IsUnique=true)]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter até 100 caracteres.")]
        public string Email { get; set; }
        [Required]
        public bool Administrador { get; set; }
    }
}
