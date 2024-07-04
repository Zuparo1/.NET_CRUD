<script>
    import { createBook } from '../../lib/books';

    let title = '';
    let isbn = '';
    let publiseringsDato = '';

    function handleSubmit() {
        createBook({ Tittel: title, ISBN: isbn, PubliseringsDato: publiseringsDato });
        title = '';
        isbn = '';
        publiseringsDato = '';
    }
</script>

<h2>Legg til Bok</h2>
<form on:submit|preventDefault={handleSubmit}>
    <input type="text" bind:value={title} placeholder="Tittel" required />
    <input type="text" bind:value={isbn} placeholder="ISBN" required />
    <input type="date" bind:value={publiseringsDato} placeholder="PubliseringsDato" required />
    <button type="submit">Legg til</button>
</form>

<style>
   form {
        display: flex;
        flex-direction: column;
        align-items: center;
    }

    input {
        margin-bottom: 1rem;
        padding: 0.5rem;
        border: 1px solid #ddd;
        border-radius: 4px;
        width: 100%;
        max-width: 400px;
    }

    button {
        padding: 0.5rem 1rem;
        background-color: #4CAF50;
        color: white;
        border: none;
        border-radius: 4px;
        cursor: pointer;
        transition: background-color 0.3s;
    }

    button:hover {
        background-color: #45a049;
    }

    h2 {
        text-align: center;
    }
</style>