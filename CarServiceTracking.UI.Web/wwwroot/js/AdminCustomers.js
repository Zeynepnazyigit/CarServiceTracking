// Admin Customers CRUD
const AdminCustomersModule = (function () {
    const apiUrl = '/api/customers';

    // GET - Tüm Müşteriler
    function getAll() {
        return fetch(apiUrl)
            .then(response => response.json())
            .catch(error => console.error('Hata (Getir Tümü):', error));
    }

    // GET - Müşteri Detayı
    function getById(id) {
        return fetch(`${apiUrl}/${id}`)
            .then(response => response.json())
            .catch(error => console.error(`Hata (Getir ${id}):`, error));
    }

    // POST - Müşteri Ekle
    function create(customerData) {
        return fetch(apiUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(customerData)
        })
            .then(response => response.json())
            .catch(error => console.error('Hata (Ekle):', error));
    }

    // PUT - Müşteri Düzenle
    function update(id, customerData) {
        return fetch(`${apiUrl}/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(customerData)
        })
            .then(response => response.json())
            .catch(error => console.error(`Hata (Düzenle ${id}):`, error));
    }

    // DELETE - Müşteri Sil
    function delete_(id) {
        return fetch(`${apiUrl}/${id}`, {
            method: 'DELETE'
        })
            .then(response => response.json())
            .catch(error => console.error(`Hata (Sil ${id}):`, error));
    }

    return {
        getAll,
        getById,
        create,
        update,
        delete: delete_
    };
})();
