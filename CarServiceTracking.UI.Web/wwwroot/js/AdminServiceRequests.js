// Admin Service Requests CRUD
const AdminServiceRequestsModule = (function () {
    const apiUrl = '/api/servicerequests';

    // GET - Tüm Servis Talepleri
    function getAll() {
        return fetch(apiUrl)
            .then(response => response.json())
            .catch(error => console.error('Hata (Getir Tümü):', error));
    }

    // GET - Servis Talebi Detayı
    function getById(id) {
        return fetch(`${apiUrl}/${id}`)
            .then(response => response.json())
            .catch(error => console.error(`Hata (Getir ${id}):`, error));
    }

    // POST - Servis Talebi Ekle
    function create(requestData) {
        return fetch(apiUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(requestData)
        })
            .then(response => response.json())
            .catch(error => console.error('Hata (Ekle):', error));
    }

    // PUT - Servis Talebi Düzenle
    function update(id, requestData) {
        return fetch(`${apiUrl}/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(requestData)
        })
            .then(response => response.json())
            .catch(error => console.error(`Hata (Düzenle ${id}):`, error));
    }

    // DELETE - Servis Talebi Sil
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
