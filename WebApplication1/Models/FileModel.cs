namespace WebApplication1.Models
{
    public abstract class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public string? UploadedBy { get; set; }
        public string? Setor { get; set; }
        public string? Empresa { get; set; }
        public string? Email { get; set; }
        public string? Solicitante { get; set; }
        public string? Fornecedor { get; set; }
        public string? Descricao { get; set; }
        public string? valor { get; set; }
        public DateTime? vencimento { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
