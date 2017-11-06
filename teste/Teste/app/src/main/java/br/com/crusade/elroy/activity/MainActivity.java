package br.com.crusade.elroy.activity;

import android.app.Fragment;
import android.app.FragmentManager;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.design.widget.BottomNavigationView;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.TextView;

import br.com.crusade.elroy.teste.R;

public class MainActivity extends AppCompatActivity {

    private TextView mTextMessage;

    private BottomNavigationView.OnNavigationItemSelectedListener mOnNavigationItemSelectedListener
            = new BottomNavigationView.OnNavigationItemSelectedListener() {

        @Override
        public boolean onNavigationItemSelected(@NonNull MenuItem item) {
            switch (item.getItemId()) {
                case R.id.navigation_home:
                    //mTextMessage.setText(R.string.title_home);
                    Fragment homefrag = new HomeFrag();
                    FragmentManager manhome = getFragmentManager();
                    manhome.beginTransaction().replace(R.id.content,homefrag).commit();
                    return true;
                case R.id.navigation_agendapastoral:
                    Fragment agendafrag = new AgendaFrag();
                    FragmentManager manAgenda = getFragmentManager();
                    manAgenda.beginTransaction().replace(R.id.content,agendafrag).commit();
                    return true;
                case R.id.navigation_pedidooracao:
                    //mTextMessage.setText(R.string.title_pedidooracao);
                    Fragment pedidoOracaoFrag = new PedidoOracaoFrag();
                    FragmentManager manPedidoOracao = getFragmentManager();
                    manPedidoOracao.beginTransaction().replace(R.id.content,pedidoOracaoFrag).commit();
                    return true;
                case R.id.navigation_eventos:
                    //mTextMessage.setText(R.string.title_eventos);
                    Fragment eventofrag = new EventoFrag();
                    FragmentManager manEvento = getFragmentManager();
                    manEvento.beginTransaction().replace(R.id.content,eventofrag).commit();
                    return true;
                case R.id.navigation_boletim:
                   // mTextMessage.setText(R.string.title_boletim);
                    Fragment boletimFrag = new BoletimFrag();
                    FragmentManager manBoletim = getFragmentManager();
                    manBoletim.beginTransaction().replace(R.id.content,boletimFrag).commit();
                    return true;
            }
            return false;
        }

    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        //mTextMessage = (TextView) findViewById(R.id.message);
        BottomNavigationView navigation = (BottomNavigationView) findViewById(R.id.navigation);
        navigation.setOnNavigationItemSelectedListener(mOnNavigationItemSelectedListener);

        //Fragmento inicial
        Fragment homefrag = new HomeFrag();
        FragmentManager manhome = getFragmentManager();
        manhome.beginTransaction().replace(R.id.content,homefrag).commit();

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_principal, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()){
            case R.id.menu_Perfil:
                Intent intentPerfil = new Intent(MainActivity.this, PerfilActivity.class);
                startActivity(intentPerfil);
                break;
        }
        return super.onOptionsItemSelected(item);
    }
}
