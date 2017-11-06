package br.com.crusade.elroy.activity;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import br.com.crusade.elroy.DAO.PerfilDAO;
import br.com.crusade.elroy.Helper.PerfilHelper;
import br.com.crusade.elroy.Model.Perfil;
import br.com.crusade.elroy.teste.R;

public class PerfilActivity extends AppCompatActivity {

    private Button btnNovo;
    private Perfil perfil;
    private PerfilHelper helper;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_perfil);

        btnNovo = (Button) findViewById(R.id.btnnovo_perfil);
        PerfilDAO dao = new PerfilDAO(this);
        perfil = dao.buscaPerfil();
        dao.close();

        helper = new PerfilHelper(this);

        if (perfil.getNome() == null) {
            btnNovo.setVisibility(btnNovo.VISIBLE);
            helper.ocultaComponentes(true);
        }
        else {
            btnNovo.setVisibility(btnNovo.GONE);
            helper.preencheformulario(perfil);
        }

        btnNovo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                helper.ocultaComponentes(false);
            }
        });

    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.menu_salvar, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()){
            case R.id.menu_Salvar:
                Perfil perfil = helper.getPerfil();
                PerfilDAO dao = new PerfilDAO(this);

                if (perfil.getId() != 0)
                    dao.altera(perfil);
                else
                    dao.insere(perfil);


                dao.close();
                Toast.makeText(PerfilActivity.this, "Perfil " + perfil.getNome() + " salvo!", Toast.LENGTH_SHORT).show();
                finish();
                break;
        }
        return super.onOptionsItemSelected(item);
    }
}
