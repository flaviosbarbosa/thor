using elroy.crusade.dominio.Enum;

namespace elroy.crusade.dominio
{
    public class Participantes
    {
        public int Id { get; set; }
        public SituacaoParticipante Situacao { get; set; }
        public Beneficiario Membro { get; set; }
        public int CodMembro { get; set; }
        public Eventos Eventos { get; set; }
        public int CodEvento { get; set; }
        public SimNao Lembrete{ get; set; }

        public Participantes()
        {
            Membro = new Beneficiario();
            Eventos = new Eventos();
            Lembrete = SimNao.Nao;
        }
    }
}
