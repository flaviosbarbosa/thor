package br.com.crusade.elroy.DAO;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.support.annotation.NonNull;
import android.support.v4.app.NotificationCompat;
import android.util.Log;
import android.widget.Toast;


import br.com.crusade.elroy.Model.Perfil;
import br.com.crusade.elroy.activity.PerfilActivity;

import static android.widget.Toast.LENGTH_LONG;

/**
 * Created by FlavioBarbosa on 18/09/17.
 */

public class PerfilDAO extends SQLiteOpenHelper {

    public PerfilDAO(Context context) {
        super(context, "Perfil", null, 2);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        String sql = "CREATE TABLE Perfil (id INTEGER PRIMARY KEY, nome TEXT NOT NULL, email TEXT NOT NULL, profissao TEXT," +
                " genero TEXT NOT NULL, membro TEXT, contato TEXT, divulgacao TEXT)";
        db.execSQL(sql);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int i, int i1) {
        String sql = "DROP TABLE IF EXISTS Perfil";
        db.execSQL(sql);
        onCreate(db);
    }

    public void insere(Perfil perfil) {
        SQLiteDatabase db = getWritableDatabase();

        ContentValues dados = pegaDadosDoPerfil(perfil);

        db.insert("Perfil", null, dados);
    }

    public Perfil  buscaPerfil() {
        String sql = "SELECT * from Perfil;";
        SQLiteDatabase db = getReadableDatabase();

        Cursor c = db.rawQuery(sql, null);
        c.moveToNext();

        Perfil perfil = new Perfil();

        try {
            perfil.setId(c.getLong(c.getColumnIndex("id")));
            perfil.setNome(c.getString(c.getColumnIndex("nome")));
            perfil.setEmail(c.getString(c.getColumnIndex("email")));
            perfil.setProfissao(c.getString(c.getColumnIndex("profissao")));
            perfil.setGenero(c.getString(c.getColumnIndex("genero")));
            perfil.setMembro(c.getString(c.getColumnIndex("membro")));
            perfil.setPermiteContato(c.getString(c.getColumnIndex("contato")));
            perfil.setPermiteDivulgarProfissao(c.getString(c.getColumnIndex("divulgacao")));
        }
        catch (Exception e){
            Log.e("Falha",e.getMessage().toString() + "-" + e.toString(),null);
        };

        c.close();
        return perfil;
    }

    @NonNull
    private ContentValues pegaDadosDoPerfil(Perfil perfil) {
        ContentValues dados = new ContentValues();

        dados.put("nome", perfil.getNome());
        dados.put("email", perfil.getEmail());
        dados.put("profissao", perfil.getProfissao());
        dados.put("genero", perfil.getGenero());
        dados.put("membro", perfil.getMembro());
        dados.put("contato", perfil.getPermiteContato());
        dados.put("divulgacao", perfil.getPermiteDivulgarProfissao());

        return dados;
    }

    public void altera(Perfil perfil) {
        SQLiteDatabase db = getWritableDatabase();

        ContentValues dados = pegaDadosDoPerfil(perfil);

        String[] params = new String[]{String.valueOf(perfil.getId())};
        db.update("Perfil", dados, "id = ?", params);
    }

}
