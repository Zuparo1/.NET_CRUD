<script>
    import { onMount } from 'svelte';
    import { books, loadBooks, deleteBook,updateBook } from '../../lib/books';

    let bokListe = [];
    let selectedBook = null;
    let showModel = false;
  
    

    onMount(async () => {
        await loadBooks();
        bokListe = $books;
    });

    function selectBook(book) {
        selectedBook = { ...book };
        showModel = true;
    }

    async function uppdateBookDetail() {
        await updateBook(selectedBook.bokID, selectedBook)    
        showModel = false;
        await loadBooks;
        bokListe = $books;
    }
</script>

<h2>Boker</h2>
<ul>
    {#each bokListe as book}
        <li>
            <div>
                <strong>{book.tittel}</strong>
                <p>ISBN: {book.isbn}</p>
                <p>Publisert: {new Date(book.publiseringsdato).toLocaleDateString()}</p>
            </div>
            <button class="update-button" on:click={() => selectBook(book)}>Update</button>
            <button on:click={() => deleteBook(book.bokID)}>Delete</button>
        </li>
    {/each}
</ul>

{#if showModel}
    <div>
        <div>
            <h2>Oppdater bok</h2>
            <label>
                Tittel:
                <input type="text" bind:value={selectedBook.tittel} />
            </label>
            <label>
                ISBN:
                <input type="text" bind:value={selectedBook.isbn} />
            </label>
            <label>
                Publiseringsdato:
                <input type="date" bind:value={selectedBook.publiseringsdato} />
            </label>
            <button on:click={uppdateBookDetail}>Lagre</button>
            <button on:click={() => showModel = false}>Avbryt</button> 
        </div>
    </div>
{/if}

<style>
    ul {
        list-style: none;
        padding: 0;
    }

    li {
        padding: 1rem;
        border-bottom: 1px solid #ddd;
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    li:last-child {
        border-bottom: none;
    }

    div {
        flex: 1;
    }

    button {
        background-color: #ff4d4d;
        color: white;
        border: none;
        padding: 0.5rem 1rem;
        border-radius: 4px;
        cursor: pointer;
        transition: background-color 0.3s;
    }

    button:hover {
        background-color: #e60000;
    }

    .update-button {
        background-color: #4caf50;
        margin-right: 0.5rem;
    }

    .update-button:hover {
        background-color: #45a049;
    }

    h2 {
        text-align: center;
    }
</style>