package br.com.crusade.elroy.activity;

import android.app.Fragment;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;

import br.com.crusade.elroy.Helper.EventoHelper;
import br.com.crusade.elroy.Model.Evento;
import br.com.crusade.elroy.teste.R;

/**
 * Created by FlavioBarbosa on 15/09/17.
 */

public class EventoFrag extends Fragment {

    private ListView listaEventos;
    private EventoHelper eventohelper;
    List<Evento> dadosEventos;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable final ViewGroup container, Bundle savedInstanceState) {
        final View root = inflater.inflate(R.layout.activity_eventofrag,container,false);

        final String[] periodos = new String[]{"1 semana", "2 semanas", "1 mês", "2 meses", "6 meses"};

        ArrayAdapter<String> adp = new ArrayAdapter<String>(root.getContext(), android.R.layout.simple_dropdown_item_1line, periodos);
        AutoCompleteTextView clubes = (AutoCompleteTextView) root.findViewById(R.id.actperiodo);
        clubes.setAdapter(adp);

        listaEventos = (ListView) root.findViewById(R.id.lstEventos);
//        String[] dados = new String[] { "Culto Vespertino", "Ensaio do Louvor", "Escola Dominical", "Culto Doutrinario", "Culto de Oração",
//                "Dia de Laser e Cultura", "1 Encontro de Homens da IPPI", "2 Encontro de Mulheres da IPPI" };

        ArrayAdapter<Evento> adapter = new ArrayAdapter<Evento>(root.getContext(), android.R.layout.simple_list_item_1, dadosEventos);
        listaEventos.setAdapter(adapter);

        listaEventos.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int position, long id) {
                Evento evento = (Evento) listaEventos.getItemAtPosition(position);

                Intent intentEventos = new Intent(container.getContext(), EventoDetalhadoActivity.class);
                intentEventos.putExtra("evento", evento);
                startActivity(intentEventos);
            }
        });

        return root;
    }



}
