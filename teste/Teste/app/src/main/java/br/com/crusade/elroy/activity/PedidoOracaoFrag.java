package br.com.crusade.elroy.activity;

import android.app.Fragment;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import br.com.crusade.elroy.teste.R;

/**
 * Created by FlavioBarbosa on 15/09/17.
 */

public class PedidoOracaoFrag extends Fragment {
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, Bundle savedInstanceState) {
        View root = inflater.inflate(R.layout.activity_pedidooracaofrag,container,false);
        return root;
    }
}
