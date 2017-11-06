package br.com.crusade.elroy.activity;

import android.app.Fragment;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import br.com.crusade.elroy.teste.R;

import static br.com.crusade.elroy.teste.R.layout.activity_homefrag;

/**
 * Created by FlavioBarbosa on 15/09/17.
 */

public class HomeFrag extends Fragment {

    private ListView listaEventos;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, Bundle savedInstanceState) {
        View root = inflater.inflate(activity_homefrag,container,false);

        listaEventos = (ListView) root.findViewById(R.id.lstEventos);
        String[] dados = new String[] { "Culto Vespertino", "Ensaio do Louvor", "Escola Dominical", "Culto Doutrinario", "Culto de Oração",
                "Dia de Laser e Cultura", "1 Encontro de Homens da IPPI", "2 Encontro de Mulheres da IPPI" };

        ArrayAdapter<String> adapter = new ArrayAdapter<String>(root.getContext(), android.R.layout.simple_list_item_1, dados);
        listaEventos.setAdapter(adapter);
        return root;
    }

}
