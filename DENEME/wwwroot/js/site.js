<script>
    function confirmDelete(id) {
        if (confirm('Bu kaydı silmek istediğinizden emin misiniz?')) {
        window.location.href = '@Url.Action("IrkSil", "IrkTanım")?id=' + id;
        }
    }
</script>
