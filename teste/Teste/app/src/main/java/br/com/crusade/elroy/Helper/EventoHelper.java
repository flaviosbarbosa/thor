package br.com.crusade.elroy.Helper;

import android.widget.TextView;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Timer;

import br.com.crusade.elroy.Model.Evento;
import br.com.crusade.elroy.activity.EventoDetalhadoActivity;
import br.com.crusade.elroy.teste.R;

/**
 * Created by FlavioBarbosa on 20/09/17.
 */

public class EventoHelper {
    private final TextView campoTitulo;
    private final TextView campoDescricao;
    private final TextView campoData;
    private final TextView campoLocal;
    private final TextView campoHorario;

    private Evento evento;

    public EventoHelper(EventoDetalhadoActivity activity){
        campoTitulo = (TextView) activity.findViewById(R.id.txtTituloEventoDetalhado);
        campoDescricao = (TextView) activity.findViewById(R.id.txtDescricaoEventoDetalhado);
        campoData = (TextView) activity.findViewById(R.id.txtDataEventoDetalhado);
        campoLocal = (TextView) activity.findViewById(R.id.txtLocalEventoDetalhado);
        campoHorario = (TextView) activity.findViewById(R.id.txtHorarioEventoDetalhado);

        evento = new Evento();
    }

    public Evento getEvento() {
        evento.setTitulo(campoTitulo.getText().toString());
        evento.setDescricao(campoDescricao.getText().toString());
        evento.setData(campoData.getText().toString());
        evento.setLocal(campoLocal.getText().toString());
        evento.setHorario(campoHorario.getText().toString());

        return evento;
    }

    public void preencheformulario(Evento evento)
    {
        campoTitulo.setText(evento.getTitulo());
        campoDescricao.setText(evento.getDescricao());
        campoData.setText(evento.getData().toString());
        campoLocal.setText(evento.getLocal());
        campoHorario.setText(evento.getHorario().toString());

        this.evento = evento;
    }

    public List<Evento> listaeventos(){
        Evento ebd = new Evento();
        ebd.setId(1);
        ebd.setTitulo("Escola Biblica");
//        ebd.setDescricao("Estudo da Palavra de Deus");
//        //ebd.setData(new Date("20/09/2017"));
//        ebd.setLocal("Igreja Presbiteriana Praia de itapuã");
//        //ebd.setHorario(new Timer("20:00:00"));
//        ebd.setPrivado("S");
//
//        Evento acaocultura = new Evento();
//        acaocultura.setId(2);
//        acaocultura.setTitulo("Dia de Laser e Cultura");
//        acaocultura.setDescricao("Açao Social");
//        //acaocultura.setData(new Date("12/10/2017"));
//        acaocultura.setLocal("Igreja Presbiteriana Praia de itapuã");
//        //acaocultura.setHorario(new Timer("09:00:00"));
//        acaocultura.setPrivado("S");
//
//        Evento ensaio = new Evento();
//        ensaio.setId(3);
//        ensaio.setTitulo("Ensaio Ministerio de Louvor");
//        ensaio.setDescricao("Ensaio das musicas para domingo a noite");
//        //ensaio.setData(new Date("24/09/2017"));
//        ensaio.setLocal("Igreja Presbiteriana Praia de itapuã");
//        //ensaio.setHorario(new Timer("16:00:00"));
//        ensaio.setPrivado("S");

        List<Evento> lista = new ArrayList<Evento>();

        lista.add(ebd);
//        lista.add(acaocultura);
//        lista.add(ensaio);

        return lista;
    }
}
