// Admin Cars CRUD
const AdminCarsModule = (function () {
    const apiUrl = '/api/cars';

    // GET - Tüm Araçlar
    function getAll() {
        return fetch(apiUrl)
            .then(response => response.json())
            .catch(error => console.error('Hata (Getir Tümü):', error));
    }

    // GET - Araç Detayı
    function getById(id) {
        return fetch(`${apiUrl}/${id}`)
            .then(response => response.json())
            .catch(error => console.error(`Hata (Getir ${id}):`, error));
    }

    // POST - Araç Ekle
    function create(carData) {
        return fetch(apiUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(carData)
        })
            .then(response => response.json())
            .catch(error => console.error('Hata (Ekle):', error));
    }

    // PUT - Araç Düzenle
    function update(id, carData) {
        return fetch(`${apiUrl}/${id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(carData)
        })
            .then(response => response.json())
            .catch(error => console.error(`Hata (Düzenle ${id}):`, error));
    }

    // DELETE - Araç Sil
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
