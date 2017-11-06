package br.com.crusade.elroy.DAO;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.support.annotation.NonNull;
import android.util.Log;

import br.com.crusade.elroy.Model.Evento;
import br.com.crusade.elroy.Model.Perfil;

/**
 * Created by FlavioBarbosa on 21/09/17.
 */

public class EventoDAO extends SQLiteOpenHelper {

    public EventoDAO(Context context) {
        super(context, "Evento", null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        String sql = "CREATE TABLE Evento (id INTEGER PRIMARY KEY, titulo TEXT NOT NULL, descricao TEXT NOT NULL, data TEXT," +
                " local TEXT NOT NULL, horario TEXT, privado TEXT)";
        db.execSQL(sql);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int i, int i1) {
        String sql = "DROP TABLE IF EXISTS Evento";
        db.execSQL(sql);
        onCreate(db);
    }

    public void insere(Evento evento) {
        SQLiteDatabase db = getWritableDatabase();

        ContentValues dados = pegaDadosDoEvento(evento);

        db.insert("Evento", null, dados);
    }

    public Perfil  buscaPerfil() {
        String sql = "SELECT * from Evento;";
        SQLiteDatabase db = getReadableDatabase();

        Cursor c = db.rawQuery(sql, null);
        c.moveToNext();

        Perfil perfil = new Perfil();

        try {
            perfil.setId(c.getLong(c.getColumnIndex("id")));
            perfil.setNome(c.getString(c.getColumnIndex("titulo")));
            perfil.setEmail(c.getString(c.getColumnIndex("descricao")));
            perfil.setProfissao(c.getString(c.getColumnIndex("data")));
            perfil.setGenero(c.getString(c.getColumnIndex("local")));
            perfil.setMembro(c.getString(c.getColumnIndex("horario")));
            perfil.setPermiteContato(c.getString(c.getColumnIndex("privado")));
        }
        catch (Exception e){
            Log.e("Falha",e.getMessage().toString() + "-" + e.toString(),null);
        };

        c.close();
        return perfil;
    }

    @NonNull
    private ContentValues pegaDadosDoEvento(Evento evento) {
        ContentValues dados = new ContentValues();

        dados.put("titulo", evento.getTitulo());
        dados.put("descricao", evento.getDescricao());
        dados.put("data", evento.getData());
        dados.put("local", evento.getLocal());
        dados.put("horario", evento.getHorario());
        dados.put("privado", evento.getPrivado());

        return dados;
    }

    public void altera(Evento evento) {
        SQLiteDatabase db = getWritableDatabase();

        ContentValues dados = pegaDadosDoEvento(evento);

        String[] params = new String[]{String.valueOf(evento.getId())};
        db.update("Evento", dados, "id = ?", params);
    }
}
