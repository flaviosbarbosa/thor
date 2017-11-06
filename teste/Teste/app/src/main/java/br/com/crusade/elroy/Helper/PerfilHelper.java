package br.com.crusade.elroy.Helper;

import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;

import br.com.crusade.elroy.Model.Perfil;
import br.com.crusade.elroy.activity.PerfilActivity;
import br.com.crusade.elroy.teste.R;

/**
 * Created by FlavioBarbosa on 18/09/17.
 */

public class PerfilHelper {

    private final EditText campoEmail;
    private final EditText campoNome;
    private final EditText campoProfissao;
    private final RadioButton campoMasculino;
    private final RadioButton campoFeminino;
    private final RadioGroup campoGenero;
    private final CheckBox campoMembro;
    private final CheckBox campoPermiteContato;
    private final CheckBox campoPermiteDivulgarProfissao;

    private Perfil perfil;


    public PerfilHelper(PerfilActivity activity){
        campoNome = (EditText) activity.findViewById(R.id.txtNome);
        campoEmail = (EditText) activity.findViewById(R.id.txtemail);
        campoProfissao = (EditText) activity.findViewById(R.id.txtProfissao);

        campoMasculino = (RadioButton) activity.findViewById(R.id.rdgMasculino);
        campoFeminino = (RadioButton) activity.findViewById(R.id.rdgFeminino);
        campoGenero = (RadioGroup) activity.findViewById(R.id.rdgGenero);

        campoMembro = (CheckBox) activity.findViewById(R.id.ckbMembro);
        campoPermiteContato = (CheckBox) activity.findViewById(R.id.ckbContato);
        campoPermiteDivulgarProfissao = (CheckBox) activity.findViewById(R.id.ckbDivulgacao);

        perfil = new Perfil();
    }

    public Perfil getPerfil() {
        perfil.setNome(campoNome.getText().toString());
        perfil.setEmail(campoEmail.getText().toString());
        perfil.setProfissao(campoProfissao.getText().toString());

        if (campoMembro.isChecked())
            perfil.setMembro("S");
        else
            perfil.setMembro("N");

        if (campoPermiteContato.isChecked())
            perfil.setPermiteContato("S");
        else
            perfil.setPermiteContato("N");

        if (campoPermiteDivulgarProfissao.isChecked())
            perfil.setPermiteDivulgarProfissao("S");
        else
            perfil.setPermiteDivulgarProfissao("N");

        if (campoMasculino.isChecked())
            perfil.setGenero("M");
        else if (campoFeminino.isChecked())
            perfil.setGenero("F");
        else
            perfil.setGenero("");

        return perfil;
    }

    public void preencheformulario(Perfil perfil)
    {
        campoNome.setText(perfil.getNome());
        campoEmail.setText(perfil.getEmail());
        campoProfissao.setText(perfil.getProfissao());

        if (perfil.getMembro().equals("S"))
            campoMembro.setChecked(true);
        else
            campoMembro.setChecked(false);

        if (perfil.getPermiteContato().equals("S"))
            campoPermiteContato.setChecked(true);
        else
            campoPermiteContato.setChecked(false);

        if (perfil.getPermiteDivulgarProfissao().equals("S"))
            campoPermiteDivulgarProfissao.setChecked(true);
        else
            campoPermiteDivulgarProfissao.setChecked(false);

        if (perfil.getGenero().equals("M"))
            campoMasculino.setChecked(true);
        if (perfil.getGenero().equals("F"))
            campoFeminino.setChecked(true);

        this.perfil = perfil;
    }

    public void ocultaComponentes(boolean pflag){
        if (pflag) {
            campoNome.setVisibility(campoNome.GONE);
            campoEmail.setVisibility(campoEmail.GONE);
            campoProfissao.setVisibility(campoProfissao.GONE);
            campoMembro.setVisibility(campoMembro.GONE);
            campoPermiteContato.setVisibility(campoPermiteContato.GONE);
            campoPermiteDivulgarProfissao.setVisibility(campoPermiteDivulgarProfissao.GONE);
            campoMasculino.setVisibility(campoMasculino.GONE);
            campoFeminino.setVisibility(campoFeminino.GONE);
        } else
        {
            campoNome.setVisibility(campoNome.VISIBLE);
            campoEmail.setVisibility(campoEmail.VISIBLE);
            campoProfissao.setVisibility(campoProfissao.VISIBLE);
            campoMembro.setVisibility(campoMembro.VISIBLE);
            campoPermiteContato.setVisibility(campoPermiteContato.VISIBLE);
            campoPermiteDivulgarProfissao.setVisibility(campoPermiteDivulgarProfissao.VISIBLE);
            campoMasculino.setVisibility(campoMasculino.VISIBLE);
            campoFeminino.setVisibility(campoFeminino.VISIBLE);
        }

    }
}
