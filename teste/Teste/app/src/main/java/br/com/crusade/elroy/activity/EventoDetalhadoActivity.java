package br.com.crusade.elroy.activity;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import br.com.crusade.elroy.Helper.EventoHelper;
import br.com.crusade.elroy.Model.Evento;
import br.com.crusade.elroy.teste.R;

public class EventoDetalhadoActivity extends AppCompatActivity {

    private EventoHelper helper;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_evento_detalhado);
        // Implementar a chegada do Evento em EventoDetalhado. GetExtra.
        Intent intent = getIntent();
        Evento evento = (Evento) intent.getSerializableExtra("evento");

        if (evento != null) {
            helper.preencheformulario(evento);
        }
    }



}
